require.config({
    paths: {
        "jquery": "jquery-1.8.2.min",
        "bootstrap": "bootstrap.min",
        "blackbird": "blackbird",
        "knockout": "knockout-2.1.0"
    },
    shim: {
        "bootstrap": ["jquery"]
    }
});

require(['awsome_app/app'], function (app) {
    app.run();
});