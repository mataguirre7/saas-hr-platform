FROM node:20-alpine AS build
WORKDIR /app

ARG BUILD_CONFIGURATION=production

COPY package.json yarn.lock ./
RUN yarn install --frozen-lockfile

COPY . .
RUN yarn build --configuration $BUILD_CONFIGURATION

FROM nginx:alpine AS runtime
COPY --from=build /app/dist/saas_hr_platform/browser /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
