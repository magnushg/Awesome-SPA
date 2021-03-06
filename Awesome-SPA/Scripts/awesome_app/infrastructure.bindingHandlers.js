﻿define(['knockout'], function (ko) {
    ko.bindingHandlers.popover = {
        init: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            var username = value.user || '';
            var caption = value.caption || '';
            var likes = value.likes || '';
            $(element).popover({ trigger: 'hover', placement: 'bottom', html: true, title: '<b>' + username + '<b>', content: '<p>'+ caption + '</p><p><b>Likes : ' + likes + '</b></p>'  });
        },
        update: function (element, valueAccessor, allBindingsAccessor) {
            
        }
    };
})