import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { IdentityResourceQuery } from './model/identityResource-query';
import { IdentityResourceViewModel } from './model/identityResource-view-model';
import { IdentityResourceEditComponent } from './identityResource-edit.component';
import { IdentityResourceDetailComponent } from './identityResource-detail.component';

/**
 * 身份资源列表页
 */
@Component({
    selector: 'identityResource-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/identityResource'
})
export class IdentityResourceListComponent extends TableQueryComponentBase<IdentityResourceViewModel, IdentityResourceQuery>  {
    /**
     * 初始化身份资源列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 获取创建弹出框组件
     */
    getCreateDialogComponent() {
        return IdentityResourceEditComponent;
    }

    /**
     * 获取详情弹出框组件
     */
    getDetailDialogComponent() {
        return IdentityResourceDetailComponent;
    }
}