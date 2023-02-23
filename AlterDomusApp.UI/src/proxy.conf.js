const PROXY_CONFIG = [
  {
    context: [
      "/api/**",
    ],
    target: "http://localhost:5088",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
