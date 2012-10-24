define(['knockout', 'awesome_app/infrastructure.xhr', 'signalR', 'noext!signalr/hubs'], function (ko, xhr) {
            return function applicationViewModel() {
                var self = this;

                self.instagramFeed = ko.observable({});
                self.searchTerm = ko.observable("bouvet");
                self.recentSearches = ko.observableArray();

                self.hashtag = ko.computed(function() {
                    return "#" + self.searchTerm();
                });
                self.searchTerm.subscribe(function(newValue) {
                    updater.listenToSearch(newValue);
                });

                self.searchForTag = function () {
                    self.update();
                };

                self.initialize = function() {
                    self.update();
                };

                self.update = function () {
                    var success = function(d) {
                        self.instagramFeed(d);
                    };

                    var data = { searchTerm: self.searchTerm() };
                    xhr.getInstagramDataForUser(data, success);
                };
                
                var updater = $.connection.updateHub;

                // Declare a function on the chat hub so the server can invoke it
                updater.update = function (message) {
                    var feed = JSON.parse(message);
                    self.instagramFeed(feed);
                };

                updater.updateSearchTerms = function(message) {
                    self.recentSearches(message);
                };

                // Start the connection
                $.connection.hub.start(function () {
                    updater.listenToSearch("bouvet");
                });

                self.initialize();
            };
        });
        