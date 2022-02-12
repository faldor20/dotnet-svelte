import type { RouteDefinition } from "svelte-spa-router";
import BookSearch from "./routes/BookSearch.svelte";
import Home from "./routes/Home.svelte";
import NotFound from "./routes/NotFound.svelte";

let routes = {
    "/": Home,
    "/BookSearch":BookSearch,
    "*": NotFound,
};

export default routes as RouteDefinition;