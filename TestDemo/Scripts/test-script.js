function loading() {
    $("#loadingbackground").show();
    $("#processing").show();
} //Loading畫面

function loading_hide() {
    setTimeout(function () {
        $("#loadingbackground").hide()
        $("#processing").hide()
    }, 1000)

} //Loading隱藏

function TransitionBtn(e) {
    $(e).closest("div.side-transition").toggleClass("active")
} //展開&收縮

function CloseModal() {
    //$("div[id*=body]").empty()
    $("[id*=Modal].show").modal("toggle");
} //關閉Modal