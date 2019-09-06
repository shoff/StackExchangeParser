namespace StackExchangeParser.Elasticsearch.Models
{
    using System;
    using System.Collections.Generic;
    using Nest;

    [ElasticsearchType(RelationName = "indexing_data")]
    public class IndexingData : IIndexable
    {
        [Number(DocValues = false, IgnoreMalformed = false, Name = "running_time")]
        public long RunningTime { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "total_documents_indexed")]
        public long TotalDocumentsIndexed { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "total_errors")]
        public int TotalErrors { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "error_break_point")]
        public int ErrorBreakpoint { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "document_threshold_adjustment")]
        public int DocumentThresholdAdjustment { get; set; }

        [Boolean(Name="retry_failed_chunks")]
        public bool RetryFailedChunks { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "maximum_chunk_size")]
        public int MaximumChunkSize { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "creation_date")]
        public DateTime CreationDate { get; set; }

        [Object(Name = "indices")]
        public ICollection<IndexData> Indices { get; set; } = new List<IndexData>();

        [Number(DocValues = false, IgnoreMalformed = false, Name = "final_failure_count")]
        public int FinalFailureCount { get; set; }

        [Ignore]
        public string IndexName { get; } = "{0}_index_data";

    }

    [ElasticsearchType(RelationName = "index_data")]
    public class IndexData
    {
        [Text(Name="name")]
        public string Name { get; set; }

        [Date(Format = "MM-dd-yyyy", Name = "creation_date")]
        public DateTime CreationDate { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "document_count")]
        public int DocumentCount { get; set; }

        [Number(DocValues = false, IgnoreMalformed = false, Name = "index_created_in_ms")]
        public long IndexCreatedInMs { get; set; }
    }
}