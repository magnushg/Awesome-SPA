define(['jquery',
        'knockout',
        'awsome_app/viewModel',
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