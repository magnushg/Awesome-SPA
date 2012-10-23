require.config({
    paths: {
        "jquery": "jquery-1.8.2.min",
        "bootstrap": "bootstrap.min",
        "blackbird": "blackbird",
        "knockout": "knockout-2.1.0",
        "signalR": "jquery.signalR-0.5.3.min"
    },
    shim: {
        "bootstrap": ["jquery"]
    }
});

require(['awesome_app/app'], function (app) {
    app.run();
});