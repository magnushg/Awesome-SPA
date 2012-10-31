define(['knockout', 'awesome_app/infrastructure.xhr', 'signalR', 'noext!signalr/hubs'], function (ko, xhr, updater) {
    var ApplicationViewModel = function () {
        var self = this;

        self.instagramFeed = ko.observable({});
        self.searchTerm = ko.observable("bouvet");
        self.recentSearches = ko.observableArray();

        self.hashtag = ko.computed(function () {
            return "#" + self.searchTerm();
        });
        self.searchTerm.subscribe(function (newValue) {
            self.updater.listenToSearch(newValue);
            log.info(newValue);
        });

        self.searchForTag = function () {
            self.update();
        };

        self.searchFor = function (searchTerm) {
            self.searchTerm(searchTerm);
            self.update();
        };
        
        self.update = function () {
            var success = function (d) {
                self.instagramFeed(d);
            };

            var data = { searchTerm: self.searchTerm() };
            xhr.getInstagramDataForUser(data, success);
        };

        self.setupHub = function () {
            self.updater = $.connection.updateHub;
            // Declare a function on the chat hub so the server can invoke it
            self.updater.update = function (message) {
                var feed = JSON.parse(message);
                self.instagramFeed(feed);
            };

            self.updater.updateSearchTerms = function (message) {
                self.recentSearches(message);
            };

            // Start the connection
            $.connection.hub.start(function () {
                self.updater.listenToSearch("bouvet");
            });
        };
        
        this.initialize();
    };
    ko.utils.extend(ApplicationViewModel.prototype, {
        initialize: function () {
            this.update();
            this.setupHub();
        }
    });
    return ApplicationViewModel;
});
