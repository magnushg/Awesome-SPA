define(['jquery',
        'knockout',
        'awesome_app/viewModel',
        'bootstrap',
        'blackbird',
        'domReady!'], function ($, ko, applicationViewModel) {
            var run = function () {
                ko.applyBindings(new applicationViewModel());
                log.debug("Application started...")
            };

            return {
                run: run
            }
        });