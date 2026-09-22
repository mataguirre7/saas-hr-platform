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
    clientSecret: '1q2w3E*',
    scope: 'offline_access saas_hr_platform',
    skipIssuerCheck: true,
    strictDiscoveryDocumentValidation: false,
    requireHttps: true
  },
  apis: {
    default: {
      url: '',
      rootNamespace: 'saas_hr_platform',
    },
  },
} as Environment;
