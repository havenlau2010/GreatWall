import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { DialogEditComponentBase } from '../../../util';
import { ClaimViewModel } from './model/claim-view-model';

/**
 * 声明编辑页
 */
@Component({
    selector: 'claim-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/claim/edit'
})
export class ClaimEditComponent extends DialogEditComponentBase<ClaimViewModel> {
    /**
     * 初始化声明编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "claim";
    }
}