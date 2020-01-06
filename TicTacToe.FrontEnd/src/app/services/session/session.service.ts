import { Injectable } from '@angular/core';
import { Session } from 'app/models/session';
import { UserModel } from 'app/models/usermodel';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  public _session: Session = <Session>{};
  private user_key: string
  constructor() { 
    this.user_key = 'User_'
  }

  public SetUserSession(userModel: UserModel) {
    var obj = {
      id: userModel.id,
      nickname: userModel.nickname
    }
    this._session.user_session = JSON.stringify(obj);
    localStorage.setItem(this.user_key, this._session.user_session);
  }

  public GetUserSession(user_key){
   
    var userStorageSession = localStorage.getItem(this.user_key);
    if (userStorageSession == null || userStorageSession == '') {
      return false;
    }
    return true;
  }

  public RemoveUserSession(){
    localStorage.removeItem(this.user_key);
  }
}
