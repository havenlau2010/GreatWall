import { QueryParameter } from '../../../../util';

/**
 * 声明查询参数
 */
export class ClaimQuery extends QueryParameter {
    /**
     * 声明标识
     */
    claimId;
    /**
     * 声明名称
     */
    name;
    /**
     * 备注
     */
    remark;
    /**
     * 起始创建时间
     */
    beginCreationTime;
    /**
     * 结束创建时间
     */
    endCreationTime;
    /**
     * 创建人标识
     */
    creatorId;
    /**
     * 起始最后修改时间
     */
    beginLastModificationTime;
    /**
     * 结束最后修改时间
     */
    endLastModificationTime;
    /**
     * 最后修改人标识
     */
    lastModifierId;
}