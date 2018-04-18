class Request {

	/**
	 * Crea una nueva instancia de la clase
	 */
	constructor() {
		this.Init();
	}

	Init() {
		this.CacheDom();
		this.BindEvents();
		this.$DataBaseDropDown.change();
	}

	/**
	 * Cache JQuery vars from the DOM
	 */
	CacheDom() {
		this.$DataBaseDropDown = $('#DataBaseName');
		this.$TableNameDropDown = $('#TableName');
		this.$RequestCount = $('#CantRequest');
		this.$ThreadsCount = $('#CantThreads');
	}

	BindEvents() {
		this.$DataBaseDropDown.on('change', (event) => this.PopulateTable(event));
	}

	PopulateTable() {
		let dropdown = this.$TableNameDropDown;
		$.post("/Request/GetTablesDB", { database: this.$DataBaseDropDown.val() }, function (response) {
			dropdown.html("");
			$.each(response.tablesnames, function (index, value) {
				dropdown.append("<option value='" + value.TableName + "'>" + value.TableName + "</option>")
			})
		});
	
	}
	SuccessStress(response) {
		Modal.SuccessModal("Exito, Prueba Finalizada <br> Cantitad de Hilos: "+response.data.CantRequest+ "<br> Cantidad de Consultas: "+response.data.CantThreads+"<br> Nombre de la base de datos: "+response.data.DatabaseName+"<br> Duración de la consulta: "+response.data.DurationRequest+"<br> Consultas Fallidas " +response.data.FailRequest+"<br> Fecha Inicio de las consultas:"+response.data.FinishDateRequest+"<br> Fecha Inicial de las consultas: "+response.data.InitialDateRequest+"<br> Consultas con exito: "+response.data.SuccessRequest+"<br> Nombre de la tabla: "+response.data.TableName)
	}
}

//Literal de objetos
var RequestModule = (function () {

	let _Request = new Request();

	return {
		SuccessStress: _Request.SuccessStress
	}
})();