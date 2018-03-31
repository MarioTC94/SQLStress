/**
 * @namespace Modal All modal functions
 */
var Modal = (function () {

    return {

        /**
         * Open a Warning modal
         * @param {String} message The text message of the modal
         * @returns {void}
         */
        WarningModal: function (message) {
            $('#textContainerWarning').empty().text(message);
            $('[data-remodal-id=modalWarning]').remodal().open();
        },

       /**
         * Open a Danger modal
         * @param {String} message The text message of the modal
         * @returns {void}
         */
        DangerModal: function (message) {
            $('#textContainerDanger').empty().text(message);
            $('[data-remodal-id=modalDanger]').remodal().open();
        },

        /**
         * Open a Success modal
         * @param {String} message The text message of the modal
         * @returns {void}
         */
        SuccessModal: function (message) {
            $('#textContainerSuccess').empty().text(message);
            $('[data-remodal-id=modalSuccess]').remodal().open();
        },

        /**
         * Open a Optional modal with two possible options
         * @param {String} message The text message of the modal
         * @param {String} textOptionOne The text of the first option
         * @param {String} textOptionTwo The text of the second option
         * @param {function} callbackOptionOne The callback to exceute if the first option is selected by the user
         * @param {function} callbackOptionTwo The callback to exceute if the second option is selected by the user
         * @returns {void}
         */
        OptionModal: function (message, textOptionOne, textOptionTwo, callbackOptionOne, callbackOptionTwo) {
            $('#textContainerOptional').empty().text(message);
            $('[data-remodal-id=modalOptional] [data-remodal-action=confirm]').text(textOptionOne);
            $('[data-remodal-id=modalOptional] [data-remodal-action=close]').text(textOptionTwo);
            $('[data-remodal-id=modalOptional]').on('click', '.remodal-confirm', callbackOptionOne);
            $('[data-remodal-id=modalOptional]').on('click', '.remodal-cancel', callbackOptionTwo);
            $('[data-remodal-id=modalOptional]').remodal().open();
        }
    }

})();
