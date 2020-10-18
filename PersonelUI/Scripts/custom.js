$(function () {
    $("#tblDepartmanlar").DataTable();
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {/*$(".btnDepartmanSil").click() burada ilkbaşta bunu kullanacaktık sonra vazgeçtik*/
        var btn = $(this);
        bootbox.confirm("Departmanı Silmek İstediğinize Emin misiniz", function (result) {
            if (result) {
                var id = btn.data("id"); /*hangi butona tıklanılmışsa onların id özelliğini getir*/
                
                $.ajax({
                    type: "GET",
                    url: "/Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove(); /*burada td den tr ye çıktık sildik*/
                    }
                });
            }
        })
    });
});


function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if (value == '') {
        $(dateElement).valid("false");
    }
    else {
        $(dateElement).valid();
    }
}