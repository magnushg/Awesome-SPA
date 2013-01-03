require.config({
    paths: {
        "noext": "noext",
        "jquery": "jquery-1.8.3.min",
        "bootstrap": "bootstrap.min",
        "blackbird": "blackbird",
        "knockout": "knockout-2.2.0",
        "signalR": "jquery.signalR-0.5.3.min",
    },
    shim: {
        "bootstrap": ["jquery"],
        "signalR": ["jquery"],
        "noext!signalr/hubs": ["signalR"]
    }
});

require(['awesome_app/app'], function (app) {
    app.run();
});