// LOGIN

$(document).on("click", "#btnIniciar", function (e) {
  Login.Inicia();
});

var Login = (function () {
  var Inicia = function Inicia() {
    Global.DeshabilitaComponente("btnIniciar");
    Global.HabilitaLoader();

    function IniciaHome(url) {
      let raiz = document.getElementById("hdfOculto").value;
      return (
        window.location.protocol +
        "//" +
        window.location.host +
        "/" +
        raiz +
        url
      );
    }

    function CreaSession(data) {
      if (data != null && data.id > 0) {
        document.location.href = IniciaHome("Home/Index");
      } else {
        Global.DeshabilitaLoader();
        Global.HabilitaComponente("btnIniciar");
        Alerta.Error("Iniciar Sesión", "Usuario o contraseña incorrecta");        
      }
    }

    let usuario = Global.GetValue("txtUsuario");
    let contrasena = Global.GetValue("txtContrasena");

    let modeloLogin = {
      Usuario: usuario.trim(),
      Contrasena: contrasena.trim(),
    };

    Global.FetchPostAsync("Acceso/AutenticaUsuario", modeloLogin).then(
      (data) => {
        CreaSession(data);
      }
    );
  };

  return {
    Inicia: Inicia,
  };
})();
