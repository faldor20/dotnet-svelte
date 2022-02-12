module Server

open Giraffe
open Saturn

open Shared

let webApp =
    router {
        get Route.hello (text "Hello from SAFE!")
        get "/" (redirectTo true "https://0.0.0.0:8085")
    }

let app =
    application {
        url "http://0.0.0.0:8085"
        use_router webApp
        memory_cache
        use_static "../../../wwwroot"
        spa
        use_gzip
    }

run app
