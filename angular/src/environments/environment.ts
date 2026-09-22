import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'saas_hr_platform',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44345/',
    redirectUri: baseUrl,
    postLogoutRedirectUri: baseUrl,
    clientId: 'saas_hr_platform_App',
    clientSecret: '1q2w3E*',
    scope: 'offline_access saas_hr_platform',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44345',
      rootNamespace: 'saas_hr_platform',
    },
  },
} as Environment;
