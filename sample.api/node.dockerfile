FROM node:14.16.0-alpine3.13
WORKDIR /app
COPY  . .
COPY ./config  .
RUN npm install
EXPOSE 3002
ENV MYSQL_CONN=sqlconn
CMD node app.js



