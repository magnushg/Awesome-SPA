define(['signalR', 'noext!signalr/hubs'], function () {
    var self = this;
	var updater = $.connection.updateHub;

	// Declare a function on the chat hub so the server can invoke it
	updater.update = function (message) {
		var feed = JSON.parse(message);
		self.instagramFeed(feed);
	};

	updater.updateSearchTerms = function (message) {
		self.recentSearches(message);
	};

	// Start the connection
	$.connection.hub.start(function () {
		updater.listenToSearch("bouvet");
	});

    return {
        listenToSearch: updater.listenToSearch
    };
})