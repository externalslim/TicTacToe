export const environment = {
  production: true,
  baseUrl: 'http://localhost:58295',
  services:{
      user_service:{
        _base: '/api/User/',
        _getUserList: 'GetUserList',
        _getUserById: 'GetUserById',
        _insert: 'Insert',
        _update: 'Update',
        _delete: 'Delete'
      },
      channel_service:{
        _base: '/api/Channel/',
        _getChannelList: 'GetChannelList',
        _getChannelById: 'GetChannelById',
        _insert: 'Insert',
        _update: 'Update',
        _delete: 'Delete'
      }
  },
  channels: {
    web: 1,
    mobile: 2
  }
};