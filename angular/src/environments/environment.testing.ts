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
    issuer: baseUrl,
    redirectUri: baseUrl,
    postLogoutRedirectUri: baseUrl,
    clientId: 'saas_hr_platform_App',
    responseType: 'code',
    scope: 'offline_access saas_hr_platform',
    requireHttps: false,
  },
  apis: {
    default: {
      url: '',
      rootNamespace: 'saas_hr_platform',
    },
  },
} as Environment;
