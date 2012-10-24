define(['knockout', 'awesome_app/infrastructure.xhr', 'signalR', 'noext!signalr/hubs'], function (ko, xhr) {
            return function applicationViewModel() {
                var self = this;

                self.instagramFeed = ko.observable({});
                self.searchTerm = ko.observable("bouvet");

                self.hashtag = ko.computed(function() {
                    return "#" + self.searchTerm();
                });
                self.searchTerm.subscribe(function(newValue) {
                    chat.send(JSON.stringify(newValue));
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
                
                chat = $.connection.updateHub;

                // Declare a function on the chat hub so the server can invoke it
                chat.add = function (message) {
                    log.info('someone searched for ' + message);
                };

                // Start the connection
                $.connection.hub.start();

                self.initialize();
            };
        });
        