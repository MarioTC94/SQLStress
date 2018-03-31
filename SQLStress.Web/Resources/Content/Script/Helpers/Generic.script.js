/**
 * @namespace Generic Module with all the Ajax functions
 */
var Generics = (function () {

    return {

        /**
         *  Excecute a normal Ajax POST call
         *  
         *  @memberOf Generic
         *  @param {String} url Url of the request 
         *  @param {JSON} parameters Json data to send to the server
         *  @param {function} successCallback Executes on success callback
         *  @param {function} failCallback Executes on logic fail
         *  @param {JSON} response JSON response from the server
         *  @returns {void}
         */
        AjaxCall: function (url, parameters, successCallback, failCallback) {
            $.ajax({
                type: 'POST',
                url: url,
                data: parameters,
                contentType: 'application/json;',
                success: function (response) {
                    if (response.isSuccess)
                        successCallback(response);
                    else
                        failCallback(response);
                }
            });
        },

        /**
        *  Execute an Ajax call for upload a file
        *  @param {String} url Url of the request 
        *  @param {FormData} formDataFile The FormData object than contains the files
        *  @param {function} successCallback Executes on success callback
        *  @param {function} failCallback Executes on logic fail
        *  @returns {void}
        */
        FileAjaxCall: function (url, formDataFile, successCallback, failCallback) {
            $.ajax({
                url: url,
                type: 'POST',
                processData: false,
                contentType: false,
                data: formDataFile,
                success: function (response) {
                    if (response.responseAction)
                        successCallBack(response);
                    else
                        failCallback(response);
                }
            });
        },

        /**
         *  Excecute an Ajax call for upload a file
         *  @param {String} url Url of the request 
         *  @param {String} form Identifider of the form so serialize
         *  @param {function} successCallback Executes on success callback
         *  @param {function} failCallback Executes on logic fail
         *  @returns {void}
         */
        AjaxFormCall: function (url, form, successCallback, failCallback) {
            $.ajax({
                type: 'POST',
                url: url,
                data: $(form).serialize(),
                success: function (response) {
                    if (response.responseAction)
                        successCallback(response)
                    else
                        failCallback(response);
                }
            });
        }
    }
})();