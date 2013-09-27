using System;
using System.Collections.Generic;
using System.Text;

namespace NovelSpider
{
    /// <summary>
    /// 采集过程接口
    /// </summary>
    public interface ICollector
    {
        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="targeturi">目标uri</param>
        /// <returns></returns>
        List<NovelInfo> GetNovelList(Uri targeturi);
        /// <summary>
        /// 获取小说基本信息
        /// </summary>
        /// <param name="novelinfouri"></param>
        /// <returns></returns>
        NovelInfo GetNovelInfo(Uri novelinfouri);
        /// <summary>
        /// 获取小说分卷信息
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        /// <returns></returns>
        List<Volume> GetVolumes(Uri novelchapterlisturi);
        /// <summary>
        /// 获取小说章节信息
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        /// <returns></returns>
        List<Chapter> GetChapterList(Uri novelchapterlisturi);
        /// <summary>
        /// 获取章节内容
        /// </summary>
        /// <param name="chapteruri"></param>
        /// <returns></returns>
        Chapter GetChapter(Uri chapteruri);
        /// <summary>
        /// 运行全部过程
        /// </summary>
        void Run(List<Uri> targetsites);
        /// <summary>
        /// 单步运行获取小说列表过程
        /// </summary>
        /// <param name="targeturi"></param>
        void RunGetNovelList(Uri targeturi);
        /// <summary>
        /// 单步运行获取小说基本信息过程
        /// </summary>
        /// <param name="novelinfouri"></param>
        void RunGetNoveInfo(Uri novelinfouri);
        /// <summary>
        /// 单步运行获取小说分卷信息过程
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        void RunGetVolumes(Uri novelchapterlisturi);
        /// <summary>
        /// 单步运行获取小说章节信息过程
        /// </summary>
        /// <param name="novelchapterlisturi"></param>
        void RunGetChapterList(Uri novelchapterlisturi);
        /// <summary>
        /// 单步运行获取小说内容过程
        /// </summary>
        /// <param name="chapteruri"></param>
        void RunGetChapter(Uri chapteruri);
        /// <summary>
        /// 小说列表获取完成时发生
        /// </summary>
        event NovelListGotEventHandler NovelListHasGot;
        /// <summary>
        /// 小说基本信息获取完成时发生
        /// </summary>
        event NovelInfoGotEventHandler NovelInfoHasGot;
        /// <summary>
        /// 分卷列表信息获取完成时发生
        /// </summary>
        event VolumeListEventHandler VolumeListHasGot;
        /// <summary>
        /// 章节列表获取完成时发生
        /// </summary>
        event ChapterListGotEventHandler ChapterListHasGot;
        /// <summary>
        /// 内容获取完成时发生
        /// </summary>
        event ChapterGotEventHandler ChapterHasGot;
        /// <summary>
        /// 过程完毕时发生
        /// </summary>
        event ProcedureFinishEventHandler ProcedureHasFinished;
    }
}
