define(function() {
        var xhrRequest = function(requestdata) {
            requestdata.type = requestdata.type || 'GET';
            requestdata.dataType = requestdata.dataType || 'jsonp';
            requestdata.contentType = requestdata.contentType || 'application/json; charset=utf-8';

            return $.ajax(requestdata);
        },
        getJSON = function(url, data, success) {
            return $.getJSON(url, data, success);
        }
        getInstagramDataForUser = function(data, successCallback) {
            return getJSON("api/images", data, successCallback);
        };

    return {
        getInstagramDataForUser: getInstagramDataForUser
    };
});
