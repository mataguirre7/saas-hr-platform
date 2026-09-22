import { Environment } from '@abp/ng.core';

const baseUrl = 'https://shrp.nzsitsolutions.com.ar';

export const environment = {
  production: true,
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
    scope: 'offline_access saas_hr_platform',
    responseType: 'code',
    requireHttps: true
  },
  apis: {
    default: {
      url: '',
      rootNamespace: 'saas_hr_platform',
    },
  },
} as Environment;
