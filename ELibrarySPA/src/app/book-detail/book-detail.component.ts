import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from './shared/book.service';
import { Book } from '../models/Book';
import Epub from 'epubjs';

@Component({
  selector: 'book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {

  constructor(private bookService: BookService,
    private activatedRoute: ActivatedRoute) { }

  book: Book;
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.bookService.get("/Book/Detail/" + params["bookId"]).subscribe(res => {
        this.book = res["value"];
        console.log(this.book["appFiles"][0]["signUrl"])
        console.log(this.book["appFiles"])
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
    
          next.addEventListener("click", function(e){
            book["package"].metadata.direction === "rtl" ? rendition.prev() : rendition.next();
            e.preventDefault();
          }, false);
    
          var prev = document.getElementById("prev");
          prev.addEventListener("click", function(e){
            book["package"].metadata.direction === "rtl" ? rendition.next() : rendition.prev();
            e.preventDefault();
          }, false);
    
          var keyListener = function(e){
    
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
    
        rendition.on("rendered", function(section){
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
    
        rendition.on("relocated", function(location){
          console.log(location);
    
          var next = book["package"].metadata.direction === "rtl" ?  document.getElementById("prev") : document.getElementById("next");
          var prev = book["package"].metadata.direction === "rtl" ?  document.getElementById("next") : document.getElementById("prev");
    
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
    
        rendition.on("layout", function(layout) {
          let viewer = document.getElementById("viewer");
    
          if (layout.spread) {
            viewer.classList.remove('single');
          } else {
            viewer.classList.add('single');
          }
        });
    
        window.addEventListener("unload", function () {
          console.log("unloading");
          book.destroy();
        });
    
        book.loaded.navigation.then((toc: any) => {
          var $select = document.getElementById("toc"),
              docfrag = document.createDocumentFragment();
    
              
          toc.forEach( chapter  => {
            var option = document.createElement("option");
            option.textContent = chapter.label;
            option.setAttribute("ref", chapter.href);
    
            docfrag.appendChild(option);
          });
    
          $select.appendChild(docfrag);
    
          $select.onchange = function(){
              var index = $select["selectedIndex"],
                  url = $select["options"][index].getAttribute("ref");
              rendition.display(url);
              return false;
          };
    
        });
    

        /* var script = document.createElement("script");
        script.innerHTML = `
        "use strict";
        document.onreadystatechange = function () {
          if (document.readyState == "complete") {
            window.reader = ePubReader("https://s3.amazonaws.com/moby-dick/moby-dick.epub", {
              restore: true
            });
          }
        };`;
        document.body.appendChild(script); */
      });
    })

  }
}
