define(['knockout', 'awesome_app/infrastructure.xhr'], function (ko, xhr) {
            return function applicationViewModel() {
                var self = this;

                self.instagramFeed = ko.observable({});

                self.initialize = function() {
                    self.update();
                };
                self.update = function() {
                    var success = function(d) {
                        self.instagramFeed(d);
                        self.setUpdate();
                    };

                    var data = { userId: 24613827 };
                    xhr.getInstagramDataForUser(data, success);
                };
                self.setUpdate = function() {
                    setTimeout(function() {
                        self.update();
                    }, 10000);
                };
                self.initialize();
            };
        });
        