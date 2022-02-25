import type { RouteDefinition } from "svelte-spa-router";
import BookSearch from "./routes/BookSearch.svelte";
import Home from "./routes/Home.svelte";
import NotFound from "./routes/NotFound.svelte";
import MyBooks from "./routes/MyBooks.svelte"
import Error from "./routes/Error.svelte"

let routes = {
    "/": Home,
    "/BookSearch": BookSearch,
    "/MyBooks":MyBooks,
    "/Error/:error":Error,
    "*": NotFound,
};

export default routes as RouteDefinition;