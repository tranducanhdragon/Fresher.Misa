var APIConfig = {
    development: "https://localhost:44396/",
    production: "http://localhost:8080/"
}

export default APIConfig[process.env.NODE_ENV]