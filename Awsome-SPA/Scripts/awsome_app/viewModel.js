﻿define(['knockout'], function(ko) {
            return function applicationViewModel() {
                var self = this;

                self.name = ko.observable('Magnus');
            };
        });
        