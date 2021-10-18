//FUNCIONES GOBALES DEL SISTEMA

var Global = (function () {
  let FetchPostAsync = async function (urlServicio, modelo) {
    const configuracion = {
      method: "POST",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(modelo),
    };

    let url = UrlCompleta(urlServicio);
    const response = await fetch(url, configuracion);
    const data = await response.json();

    return data;
  };

  let FetchGetAsync = async function (urlServicio) {
    let url = UrlCompleta(urlServicio);
    const response = await fetch(url);
    const data = await response.json();

    return data;
  };

  let GetValue = function (idInput) {
    return document.getElementById(idInput).value;
  };

  let UrlCompleta = function (urlServicio) {
    return (
      window.location.protocol +
      "//" +
      window.location.host +
      "/" +
      GetValue("hdfOculto") +
      urlServicio
    );
  };

  let HabilitaLoader = function () {
    console.log("");
  };

  let DeshabilitaLoader = function () {
    console.log("");
  };

  let DeshabilitaComponente = function (idInput) {
    document.getElementById(idInput).disabled = true;
  };

  let HabilitaComponente = function (idInput) {
    document.getElementById(idInput).disabled = false;
  };
  
  return {
    GetValue: GetValue,
    FetchGetAsync: FetchGetAsync,
    FetchPostAsync: FetchPostAsync,
    HabilitaLoader: HabilitaLoader,
    DeshabilitaLoader: DeshabilitaLoader,
    DeshabilitaComponente: DeshabilitaComponente,
    HabilitaComponente: HabilitaComponente,
  };
})();
