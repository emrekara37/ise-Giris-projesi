function veriSil(btnSecici, ajaxUrl, mesaj) {
  $(btnSecici).on('click', function () {
    var id = $(this).data('id');
    var btn = $(this);
    swal({
      title: "Silmek İstediğinize Emin Misiniz ? ",
      text: "Bu işlem geri alınamaz!",
      type: "warning",
      showCancelButton: true,
      confirmButtonColor: "#DD6B55",
      confirmButtonText: "Sil!",
      cancelButtonText: "Hayır!",
      closeOnConfirm: true,

    },
      function (isConfirm) {

        if (isConfirm) {
          $.ajax({
            url: ajaxUrl + id,

            success: function (sonuc) {

              if (sonuc) {
                $.notify(mesaj, "success");
                btn.closest('tr').hide(1000);

              } else {
                $.notify("Hata Oluştu", "danger");
              }


            }

          });
        } else {
          $.notify("İşlem iptal edildi", "danger");
        }
      });
  });

}
function sehirDuzenle() {


  $(".btnSehirDuzenle").on('click',
    function () {
      var id = $(this).data('id');
      $(this).removeClass("btn-warning").addClass("btn-success").text("Kaydet");
      var txtSecici = $(".txtSehirAdi[data-id=" + id + "]");
      txtSecici.removeAttr("disabled");
      $(this).on('click',
        function () {
          if (txtSecici.val() == "") {
            $.notify("Şehir ismi boş", "warning");
          } else {
            $.ajax({
              url: "/Sehir/Duzenle",
              data: { cityName: txtSecici.val(), id: id },
              dataType: "json",
              type: "post",
              success: function (result) {

                if (result) {

                  window.location.reload();
                } else {
                  $.notify("Düzenleme işlemi başarısız ! ", "warning");
                }

              }
            });
          }
        });
    });
}
function guzergahTipDuzenle() {
  $(".btnGuzergahTipDuzenle").on('click',
    function () {
      var id = $(this).data('id');
      $(this).removeClass("btn-warning").addClass("btn-success").text("Kaydet");
      var txtSecici = $(".txtGuzergahTip[data-id=" + id + "]");
      txtSecici.removeAttr("disabled");
      $(this).on('click',
        function () {
          if (txtSecici.val() == "") {
            $.notify("Güzergah tip adı boş", "warning");
          } else {
            $.ajax({
              url: "/GuzergahTip/TipDuzenle",
              data: { routeTypeName: txtSecici.val(), id: id },
              dataType: "json",
              type: "post",
              success: function (result) {

                if (result) {

                  window.location.reload();
                } else {
                  $.notify("Düzenleme işlemi başarısız ! ", "warning");
                }

              }
            });
          }
        });
    });
}

/**
 * Kullanılmayan Ajax Metodları
 */
function sehirList() {
  $.ajax({
    url: "/Sehir/JsonSehirList",
    dataType: "json",
    type: "get",
    success: function (result) {
      $.each(result,
        function (key, value) {

          $("#sehirList").append("<option value=" + value.Id + ">" + value.CityName + "</option>");


        });
    }

  });
}
function guzergahTipList() {
  $.ajax({
    url: "/GuzergahTip/JsonGuzergahTipList",
    dataType: "json",
    type: "get",
    success: function (result) {
      $.each(result,
        function (key, value) {

          $("#guzergahTipList").append("<option value=" + value.Id + ">" + value.RouteTypeName + "</option>");


        });
    }

  });
}
