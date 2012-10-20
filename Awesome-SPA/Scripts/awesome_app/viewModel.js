define(['knockout', 'awesome_app/infrastructure.xhr'], function (ko, xhr) {
            return function applicationViewModel() {
                var self = this;

                self.instagramFeed = ko.observable({});
                self.searchTerm = ko.observable("bouvet");
                
                self.searchForTag = function () {
                    self.update();
                }

                self.initialize = function() {
                    self.update();
                };
                self.update = function() {
                    var success = function(d) {
                        self.instagramFeed(d);
                        self.setUpdate();
                    };

                    var data = { searchTerm: self.searchTerm() };
                    xhr.getInstagramDataForUser(data, success);
                };
                self.setUpdate = function() {
                    setTimeout(function() {
                        self.update();
                    }, 30000);
                };
                self.initialize();
            };
        });
        