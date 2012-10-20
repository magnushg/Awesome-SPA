define(['knockout', 'awesome_app/infrastructure.xhr'], function (ko, xhr) {
            return function applicationViewModel() {
                var self = this;

                self.instagramFeed = ko.observable({});

                self.initialize = function() {
                    var success = function(d) {
                        self.instagramFeed(d);
                    };

                    var data = { userId: 24613827 };
                    xhr.getInstagramDataForUser(data, success);
                };
                self.initialize();
            };
        });
        