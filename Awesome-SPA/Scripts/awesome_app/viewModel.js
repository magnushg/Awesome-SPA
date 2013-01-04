define(['knockout', 'awesome_app/infrastructure.xhr', 'signalR', 'noext!signalr/hubs'], function (ko, xhr) {
    var ApplicationViewModel = function () {
        var self = this;
        
        self.instagramFeed = ko.observable({});
        self.searchTerm = ko.observable("bouvet");
        self.recentSearches = ko.observableArray();
        self.hashtag = ko.computed(self.getHashTag, self);

        self.searchTerm.subscribe(function (newValue) {
            self.updater.listenToSearch(newValue);
            log.info(newValue);
        });
        self.updateData = function(feed) {
            self.instagramFeed(feed);
        };

        self.searchFor = function(search) {
            self.searchTerm(search);
            self.update();
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
        getHashTag: function () {
            return "#" + this.searchTerm();
        },
        initialize: function () {
            this.update();
            this.setupHub();
        },
        update: function () {
            var data = { searchTerm: this.searchTerm() };
            xhr.getInstagramDataForUser(data, this.updateData);
        },
        searchForTag: function () {
            this.update();
        }
    });
    return ApplicationViewModel;
});
