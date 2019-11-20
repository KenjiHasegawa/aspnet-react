"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_router_dom_1 = require("react-router-dom");
var Layout_1 = require("./components/Layout");
var Home_1 = require("./components/Home");
var FetchProduct_1 = require("./components/FetchProduct");
exports.routes = React.createElement(Layout_1.Layout, null,
    React.createElement(react_router_dom_1.Route, { exact: true, path: '/', component: Home_1.Home }),
    React.createElement(react_router_dom_1.Route, { path: '/fetchproduct', component: FetchProduct_1.FetchProduct }));
//# sourceMappingURL=routes.js.map