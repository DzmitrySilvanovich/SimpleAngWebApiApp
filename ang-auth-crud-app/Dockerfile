# Stage 1: Compile and Build angular codebase

# Use official node image as the base image
FROM node:latest AS build

# Set the working directory
WORKDIR /usr/local/app

# Add the source code to app
COPY ./ /usr/local/app/

# Install all the dependencies
RUN npm install

# Generate the build of the application
RUN npm run build


# Stage 2: Serve app with nginx server

# Use official nginx image as the base image
FROM nginx:latest

COPY nginx.conf /etc/nginx/nginx.conf

# Copy the build output to replace the default nginx contents. Added browser must have
COPY --from=build /usr/local/app/dist/ang-auth-crud-app/browser /usr/share/nginx/html

# Expose port 80
EXPOSE 80