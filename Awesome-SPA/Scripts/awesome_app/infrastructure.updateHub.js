define(['signalR', 'noext!signalr/hubs'], function () {
    var self = this;
    self.hub = $.connection.updateHub;
    self.feed = { };

        // Declare a function on the chat hub so the server can invoke it
    hub.update = function(message) {
        var feed = JSON.parse(message);
        self.feed(feed);
    };

    hub.updateSearchTerms = function(message) {
        self.recentSearches(message);
    };

    self.initialize = function(feed) {
        // Start the connection
        self.feed = feed;
        $.connection.hub.start();
    };

    return {
        listenToSearch: self.hub.listenToSearch,
        initialize: self.initialize
    };
})