import Vue from "vue";
import VueRouter from "vue-router";
import HomePage from './pages/layout/home-page'
// import LoginPage from "./pages/auth/pages/login";

// import authorizationRoutes from "./routes/authorizationRoutes";
// import orderRoutes from "./routes/orderRoutes";

Vue.use(VueRouter);

const routes = [
    // ...authorizationRoutes,
    // ...gameRoutes,
    // ...orderRoutes,
    {
        path: "*",
        component: HomePage
    }
];

let router = new VueRouter({
    mode: "history",
    routes
});

export default router;
