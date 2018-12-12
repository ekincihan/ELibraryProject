var globalKWP = {
    language: 'tr',
    dataTableInstance: function (tableName, headbuttonArr, lengthMenuArr) {
        var btnArray = [];
        var languageUrl = '';
        if (lengthMenuArr == undefined) {
            lengthMenuArr = [[10, 25, 50, -1], [10, 25, 50, "Tümü"]];
            var item = { extend: 'pageLength' };
            btnArray.push(item);
        }
        if (headbuttonArr == undefined) {
            headbuttonArr = [
                { extend: 'copy' }, { extend: 'pdf', title: tableName }, { extend: 'excel', title: tableName },
                { extend: 'print' }
            ];
        }
        for (var btn in headbuttonArr) {
            btnArray.push(headbuttonArr[btn]);
        }
        if (globalKWP.language == 'tr') {
            languageUrl = '/Custom/tr.txt';

        }
        var dataTable = $('#' + tableName).DataTable({
            "dom": 'Bfrtip',
            buttons: btnArray,
            "lengthMenu": lengthMenuArr,
            "language": { "url": languageUrl }
        });
        return dataTable;
    }
}