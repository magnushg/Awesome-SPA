define(['knockout'], function (ko) {
    ko.bindingHandlers.popover = {
        init: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            var username = value.user || '';
            var caption = value.caption || '';
            $(element).popover({ trigger: 'hover', placement: 'bottom', html: true, title: '<b>' + username + '<b>', content: caption });
        },
        update: function (element, valueAccessor, allBindingsAccessor) {
            // Leave as before
        }
    };
})