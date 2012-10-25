define(['knockout', 'awesome_app/infrastructure.xhr', 'awesome_app/infrastructure.updateHub'], function (ko, xhr, updater) {
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
                    log.info(newValue);
                });

                self.searchForTag = function () {
                    self.update();
                };

                self.searchFor = function(searchTerm) {
                    self.searchTerm(searchTerm);
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
                self.initialize();
            };
        });
        