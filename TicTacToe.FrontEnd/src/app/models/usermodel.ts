export interface UserModel {
    id: number,
    nickname: string,
    email: string,
    password: string,
    channelId: number,
    winRate: number,
    createdDate: Date,
    isDeleted: boolean
}