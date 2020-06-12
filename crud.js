/// 


///    A Ç I K L A M A
//
//  Bu crud.js ajax fonksiyonlarını crud işlemleri için yazılmıştır.
//  Fakat asp.net mvc ile devextreme kütüphanesi kullanılıp bu kütüphane içerisindeki 
//  ajax metodları kullanılmıştır. 
//  Buradaki crud fonkiyonlarına karşılık gelen HomeController da metodlar mevcuttur. 
//  Bu metodlar buradaki ajax fonksiyonları kullanılmadığı için yorum satırna alınmıştır
//  ve DevExtreme' in kendi formuna ait crud işlemlerine karşılık gelen başka bir Controller(ModelDataController) yazılmıştır.
//  
//Load Data
function loadData() {
    $.ajax({
        url: "/DataModel/Get",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.CARIKOD + '</td>';
                html += '<td>' + item.CARIISIM + '</td>';
                html += '<td>' + item.ADRES + '</td>';
                html += '<td>' + item.IL + '</td>';
                html += '<td>' + item.ILCE + '</td>';
                html += '<td>' + item.ULKEKODU + '</td>';
                html += '<td>' + item.TELEFON + '</td>';
                html += '<td>' + item.FAX + '</td>';
                html += '<td>' + item.VERGIDAIRESI + '</td>';
                html += '<td>' + item.VERGINO + '</td>';
                html += '<td>' + item.TCNO + '</td>';
                html += '<td>' + item.POSTAKODU + '</td>';
                html += '<td>' + item.TIP + '</td>';
                html += '<td>' + item.EMAIL + '</td>';
                html += '<td>' + item.WEBADRESI + '</td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Add
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var Obj = {
        CARIKOD: $('#CARIKOD').val(),
        CARIISIM: $('#CARIISIM').val(),
        ADRES: $('#ADRES').val(),
        IL: $('#IL').val(),
        ILCE: $('#ILCE').val(),
        ULKEKODU: $('#ULKEKODU').val("TR"),
        TELEFON: $('#TELEFON').val(),
        FAX: $('#FAX').val(),
        VERGIDAIRE: $('#VERGIDAIRESI').val(),
        VERGINO: $('#VERGINO').val(),
        TCNO: $('#TCNO').val(),
        POSTAKODU: $('#POSTAKODU').val(),
        TIP: $('#TIP').val(),
        EMAIL: $('#EMAIL').val(),
        WEBADRESI: $('#WEBADRESI').val()
    };
    $.ajax({
        url: "/DataModel/Post",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//
function getbyID(ID) {
    $('#CARIKOD').css('border-color', 'lightgrey');
    $('#CARIISIM').css('border-color', 'lightgrey');
    $('#ADRES').css('border-color', 'lightgrey');
    $('#IL').css('border-color', 'lightgrey');
    $('#ILCE').css('border-color', 'lightgrey');
    $('#ULKEKODU').css('border-color', 'lightgrey');
    $('#TELEFON').css('border-color', 'lightgrey');
    $('#FAX').css('border-color', 'lightgrey');
    $('#VERGIDAIRESI').css('border-color', 'lightgrey');
    $('#VERGINO').css('border-color', 'lightgrey');
    $('#TCNO').css('border-color', 'lightgrey');
    $('#POSTAKODU').css('border-color', 'lightgrey');
    $('#TIP').css('border-color', 'lightgrey');
    $('#EMAIL').css('border-color', 'lightgrey');
    $('#WEBADRESI').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Home/GetbyID/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CARIKOD').val(result.CARIKOD);
            $('#CARIISIM').val(result.CARIISIM);
            $('#ADRES').val(result.ADRES);
            $('#IL').val(result.IL);
            $('#ILCE').val(result.ILCE);
            $('#ULKEKODU').val(result.ULKEKODU);
            $('#TELEFON').val(result.TELEFON);
            $('#FAX').val(result.FAX);
            $('#VERGIDAIRESI').val(result.VERGIDAIRE);
            $('#VERGINO').val(result.VERGINO);
            $('#TCNO').val(result.TCNO);
            $('#POSTAKODU').val(result.POSTAKODU);
            $('#TIP').val(result.TIP);
            $('#EMAIL').val(result.EMAIL);
            $('#WEBADRESI').val(result.WEBADRESI);

            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var Obj = {
        CARIKOD: $('#CARIKOD').val(),
        CARIISIM: $('#CARIISIM').val(),
        ADRES: $('#ADRES').val(),
        IL: $('#IL').val(),
        ILCE: $('#ILCE').val(),
        ULKEKODU: $('#ULKEKODU').val("TR"),
        TELEFON: $('#TELEFON').val(),
        FAX: $('#FAX').val(),
        VERGIDAIRE: $('#VERGIDAIRESI').val(),
        VERGINO: $('#VERGINO').val(),
        TCNO: $('#TCNO').val(),
        POSTAKODU: $('#POSTAKODU').val(),
        TIP: $('#TIP').val(),
        EMAIL: $('#EMAIL').val(),
        WEBADRESI: $('#WEBADRESI').val(),
    };
    $.ajax({
        url: "/ModelData/Put",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#CARIKOD').val("");
            $('#CARIISIM').val("");
            $('#ADRES').val("");
            $('#IL').val("");
            $('#ILCE').val("");
            $('#ULKEKODU').val("TR");
            $('#TELEFON').val("");
            $('#FAX').val("");
            $('#VERGIDAIRESI').val("");
            $('#VERGINO').val("");
            $('#TCNO').val("");
            $('#POSTAKODU').val("");
            $('#TIP').val("");
            $('#EMAIL').val("");
            $('#WEBADRESI').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//
function Delete(ID) {
    var ans = confirm("Bu kayıt silinecek, emin misiniz?");
    if (ans) {
        $.ajax({
            url: "/ModelData/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//
function clearTextBox() {
    $('#CARIKOD').val("");
    $('#CARIISIM').val("");
    $('#ADRES').val("");
    $('#IL').val("");
    $('#ILCE').val("");
    $('#ULKEKODU').val("TR");
    $('#TELEFON').val("");
    $('#FAX').val("");
    $('#VERGIDAIRESI').val("");
    $('#VERGINO').val("");
    $('#TCNO').val("");
    $('#POSTAKODU').val("");
    $('#TIP').val("");
    $('#EMAIL').val("");
    $('#WEBADRESI').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#CARIKOD').css('border-color', 'lightgrey');
    $('#CARIISIM').css('border-color', 'lightgrey');
    $('#ADRES').css('border-color', 'lightgrey');
    $('#IL').css('border-color', 'lightgrey');
    $('#ILCE').css('border-color', 'lightgrey');
    $('#ULKEKODU').css('border-color', 'lightgrey');
    $('#TELEFON').css('border-color', 'lightgrey');
    $('#FAX').css('border-color', 'lightgrey');
    $('#VERGIDAIRESI').css('border-color', 'lightgrey');
    $('#VERGINO').css('border-color', 'lightgrey');
    $('#TCNO').css('border-color', 'lightgrey');
    $('#POSTAKODU').css('border-color', 'lightgrey');
    $('#TIP').css('border-color', 'lightgrey');
    $('#EMAIL').css('border-color', 'lightgrey');
    $('#WEBADRESI').css('border-color', 'lightgrey');
}
//
function validate() {
    var isValid = true;

    if ($('#CARIKOD').val().trim() == "") {
        $('#CARIKOD').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CARIKOD').css('border-color', 'lightgrey');
    }
    if ($('#CARIISIM').val().trim() == "") {
        $('#CARIISIM').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CARIISIM').css('border-color', 'lightgrey');
    }
    if ($('#ADRES').val().trim() == "") {
        $('#ADRES').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ADRES').css('border-color', 'lightgrey');
    }
    if ($('#IL').val().trim() == "") {
        $('#IL').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#IL').css('border-color', 'lightgrey');
    }
    if ($('#ILCE').val().trim() == "") {
        $('#ILCE').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ILCE').css('border-color', 'lightgrey');
    }

    return isValid;
}