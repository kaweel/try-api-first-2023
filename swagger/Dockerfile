FROM golang:1.20.5-alpine3.18 as builder
RUN export GO111MODULE=on
WORKDIR /go/src
COPY mock-server/go ./go
COPY mock-server/main.go .
RUN sed -i 's/.\/go/mock-server\/go/g' main.go
RUN go mod init mock-server
RUN go mod tidy
RUN go build main.go 

FROM golang:1.20.5-alpine3.18
COPY --from=builder /go/src/main ./ 
EXPOSE 8080 
ENTRYPOINT ["./main"]