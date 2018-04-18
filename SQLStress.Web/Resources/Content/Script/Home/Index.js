class Index {

	/**
	 * Crea una nueva instancia de la clase
	 */
	constructor() {
		this.Init();
	}

	Init() {
		this.CacheDom();
		this.BindEvents();
	}

	/**
	 * Cache JQuery vars from the DOM
	 */
	CacheDom() {
		this.$WindowsAuthentication = $('#WindowsAuthentication');
		this.$UserName = $('#User');
		this.$Password = $('#Password');
		this.$OkButtonSuccessModal = $('.remodal-confirm');
	}

	BindEvents() {
		this.$WindowsAuthentication.on('change', (event) => this.OnChangeWindowsAuthentication(event));
		this.$OkButtonSuccessModal.on('click', (event) => this.RedirectToRequest(event));
	}

	/**
	 * Disabled the required inputs
	 * @param {JQuery.Event} event The event object of Jquery
	 */
	OnChangeWindowsAuthentication(event) {
		this.$UserName.prop('disabled', this.$WindowsAuthentication.is(':checked'));
		this.$Password.prop('disabled', this.$WindowsAuthentication.is(':checked'));
	}

	SuccessConnection(response) {
		if (response.isSuccess) {
			Modal.SuccessModal(response.responseText);
		} else {
			Modal.DangerModal(response.responseText);
		}
	}

	RedirectToRequest() {
		window.location.href = "/Request/CreateRequest";
	}
}

//Literal de objetos
var IndexModule = (function () {

	let _Index = new Index();

	return {
		SuccessConnection: _Index.SuccessConnection
	}
})();