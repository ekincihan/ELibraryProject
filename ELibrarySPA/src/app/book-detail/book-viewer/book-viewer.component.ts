import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import Epub from 'epubjs';
import { BookService } from '../shared/book.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../models/Book';

@Component({
  selector: 'app-book-viewer',
  templateUrl: './book-viewer.component.html',
  styleUrls: ['./book-viewer.component.css']
})
export class BookViewerComponent implements OnInit {
  book: Book;
  epubBook: any;
  url: string;
  epubViewerOn = false;
  readPage = {
    userId: '',
    id: '00000000-0000-0000-0000-000000000000',
    bookId: '',
    page: 0,
  }

  @ViewChild('pdfView') pdfView: ElementRef;
  constructor(private bookService: BookService,
      private router: Router,
    private activatedRoute: ActivatedRoute) {

  }

  setReadPage(isAtHere: boolean){
    if(isAtHere){
      let currentPageNumber = document.getElementById("pageNumber")["value"];
      this.readPage.page = parseInt(currentPageNumber);
    }
    this.readPage.bookId = this.book.id;
    this.readPage.userId = JSON.parse(localStorage.getItem('user'))["id"];
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.bookService.get("/Book/Detail/" + params["bookId"]).subscribe(res => {
        this.book = res["value"];
        this.getPageReaded();
        let ext = res["value"]["appFiles"][0].extension;

        let isPdf = false;
        if(ext == "application/epub+zip")
          isPdf = false;
        else if(ext == "application/pdf")
          isPdf = true;

        if (isPdf) {
          this.url = res["value"]["appFiles"][0].signUrl;
        } else {
          this.openEpubViewer();
        }
      });
    })

  }

  getPageReaded(){
    this.setReadPage(false);
    //console.log('this.readPageres book',this.readPage);

    this.bookService.post('User/UserReadPage',this.readPage).subscribe(res =>{
       this.readPage["id"] = (res) ? res["id"] : '00000000-0000-0000-0000-000000000000';
      if(!this.epubViewerOn && res){
        setTimeout(() => {
          document.getElementById("pageNumber")["value"] = res["page"];
          var event = new Event('change');
          document.getElementById("pageNumber").addEventListener('change', function (e) { /* ... */ }, false);
            document.getElementById("pageNumber").dispatchEvent(event);
        }, 2000);
      }
    })
  }

  atHere(){
    this.setReadPage(true);
    this.sendPageNumber();
  }

  sendPageNumber(){
    this.bookService.post("User/ReadPage",this.readPage).subscribe(res => {
      if(res['bookId']){
          this.router.navigate(['/kitap-detay/'+res['bookId']]);
      }
    });
  }
  openEpubViewer() {
    this.epubViewerOn = true;
    var params = URLSearchParams && new URLSearchParams(document.location.search.substring(1));
    var url = params && params.get("url") && decodeURIComponent(params.get("url"));
    var currentSectionIndex = (params && params.get("loc")) ? params.get("loc") : undefined;

    // Load the opf
    var book = Epub(url || "https://s3.amazonaws.com/moby-dick/moby-dick.epub");
    var rendition = book.renderTo("viewer", {
      width: "100%",
      height: 600,
      spread: "always"
    });

    rendition.display(currentSectionIndex);

    book.ready.then(() => {

      var next = document.getElementById("next");

      next.addEventListener("click", function (e) {
        book["package"].metadata.direction === "rtl" ? rendition.prev() : rendition.next();
        e.preventDefault();
      }, false);

      var prev = document.getElementById("prev");
      prev.addEventListener("click", function (e) {
        book["package"].metadata.direction === "rtl" ? rendition.next() : rendition.prev();
        e.preventDefault();
      }, false);

      var keyListener = function (e) {

        // Left Key
        if ((e.keyCode || e.which) == 37) {
          book["package"].metadata.direction === "rtl" ? rendition.next() : rendition.prev();
        }

        // Right Key
        if ((e.keyCode || e.which) == 39) {
          book["package"].metadata.direction === "rtl" ? rendition.prev() : rendition.next();
        }

      };

      rendition.on("keyup", keyListener);
      document.addEventListener("keyup", keyListener, false);

    })

    var title = document.getElementById("title");

    rendition.on("rendered", function (section) {
      var current = book.navigation && book.navigation.get(section.href);

      if (current) {
        var $select = document.getElementById("toc");
        var $selected = $select.querySelector("option[selected]");
        if ($selected) {
          $selected.removeAttribute("selected");
        }

        var $options = $select.querySelectorAll("option");
        for (var i = 0; i < $options.length; ++i) {
          let selected = $options[i].getAttribute("ref") === current.href;
          if (selected) {
            $options[i].setAttribute("selected", "");
          }
        }
      }

    });

    rendition.on("relocated", function (location) {
      var next = book["package"].metadata.direction === "rtl" ? document.getElementById("prev") : document.getElementById("next");
      var prev = book["package"].metadata.direction === "rtl" ? document.getElementById("next") : document.getElementById("prev");

      if (location.atEnd) {
        next.style.visibility = "hidden";
      } else {
        next.style.visibility = "visible";
      }

      if (location.atStart) {
        prev.style.visibility = "hidden";
      } else {
        prev.style.visibility = "visible";
      }

    });

    rendition.on("layout", function (layout) {
      let viewer = document.getElementById("viewer");

      if (layout.spread) {
        viewer.classList.remove('single');
      } else {
        viewer.classList.add('single');
      }
    });

    window.addEventListener("unload", function () {
      book.destroy();
    });

    book.loaded.navigation.then((toc: any) => {
      var $select = document.getElementById("toc"),
        docfrag = document.createDocumentFragment();

      toc.forEach(chapter => {
        var option = document.createElement("option");
        option.textContent = chapter.label;
        option.setAttribute("ref", chapter.href);

        docfrag.appendChild(option);
      });

      $select.appendChild(docfrag);

      $select.onchange = function () {
        var index = $select["selectedIndex"],
          url = $select["options"][index].getAttribute("ref");
        rendition.display(url);
        return false;
      };

    });
  }

}
