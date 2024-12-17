$(document).on("click", ".abrirModal", function () {

    $("#ConsecutivoProducto").val($(this).attr("data-id"));
    $("#Nombre").text($(this).attr("data-name"));

    alert(consecutivo + " " + nombre);
})