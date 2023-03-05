Sample project consuming banks route on BrasilApi to understaind how Jaeger with Open Telemetry works.

In this project i used:
- OpenTelemetry
- Jaeger
- Refit

To run, you need to:
- Go to root folder and execute the command docker-compose up -d to up a container with Jaeger.
- Go to the Sample.OpenTelemetry.API folder and execute the command docker run.

If all works fine, you will be able to check Jaeger by the address: http://localhost:16686/ and the swagger on the port available on console + /swagger

References:
https://brasilapi.com.br/docs
