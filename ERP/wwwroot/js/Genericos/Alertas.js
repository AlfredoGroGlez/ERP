//ALERTAS DEL SISTEMA

var Alerta = (function () {
  //API

  let Error = function (titulo, mensaje) {
    Swal.fire(titulo, mensaje, "error");
  };

  return {
    Error: Error,
  };
})();
